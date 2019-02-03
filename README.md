# pgo-weatherbot
**Get accurate in-game forecasts for Pokemon GO delivered straight to your Discord server**

###### Disclaimer
This project is not terribly well-coded, but it works for me. I am a self-taught programmer with an educational background in social science, not computer science...  
It should have code-first db creation and seeding. It does not. One day I will probably add that, if I ever have time...

ALSO: GitHub LIES. While there is a lot of JavaScript in this project (including AngularJS 1.7.x) it'd be a misnomer to call it a JavaScript project. It's a .NET MVC6 Web API 2 project. Sorry. *shrugs*

## TO RUN:

1. Clone the project and open  the .sln file in Visual Studio
2. Create a database and use the SQL scripts in the SQL folder to populate the required tables 
3. Update web.config with your database connection string
4. Update Resources.resx with the required information:
   * change admin username and password (or at least change the default password)
   * add your Discord webhook url
   * add your AccuWeather API key and location ID 
   * add your TimeZoneId (this should be the .NET timezone ID for your location, i.e. "Eastern Standard Time")
5. Build, compile, publish. You can run locally on IIS or publish to a Windows hosting service. (Sorry, I know .NET hosting is usually more expensive; but it's what I am famililar with)

## ONCE IT IS RUNNING:

Before it will work, you will need to log in using the admin credentials, go to the weather page, and use the cogs to access the admin panel. From there, set your pull time.
**Pull times change!** That's why this app pulls forecasts hourly - so you can compare each forecast with in-game weather boosts and determine which 3 of the 24 forecasts in a day were the ones used by Niantic.
If you don't know what the pull time is, use 1 am to start, and adjust once you figure it out.

If everything is set up correctly, the bot will collect hourly forecasts and then post the pull-time forecasts (in 8 hour blocks) to your webhook.

Your posted forecasts on Discord will look a lot like this (but without any mention of boosted bosses):

![Forecast](https://github.com/thornleaf/pgo-weatherbot/blob/master/WeatherBot/Images/samples/Forecast.PNG?raw=true)

And the weather page, once the app has collected some data, should look something like this:
![WebForecast](https://github.com/thornleaf/pgo-weatherbot/blob/master/WeatherBot/Images/samples/WebForecst.PNG?raw=true)

##### Everything I Know About In-Game Weather

Niantic uses AccuWeather hourly forecasts to determine in-game weather. There is a 1:1 correlation (with windy exceptions) between AccuWeather’s icon id/text names and in-game weather boosts and visual effects. Since visual effects don’t have an impact on gameplay, I’m focusing on weather boosts here. 

Many redditors have observed that weather is based on level 9 or 10 s2 cells, with the location key for that cell based on the geographic center of the cell (so use AccuWeather's geocoordinates API to get your location key)

In order to predict in-game weather for your location, you need several pieces of information:

* You need to know which level 9 (or 10?) s2 cell you are in, and the geocoordinates for that cell's center point. 
* You need an AccuWeather API key. The free version allows you to make up to 50 calls per day, which will cover two cells - each of which requires 24 calls per day (once per hour). 
* AccuWeather forecast APIs require the use of a location key. You need to figure out which location key is valid for your area - I recommend using the Geoposition Search with the geo-coordinates for the center of your cell. However, if you’ve noticed that weather is always consistent across your entire town/city, then you can probably just use the City Search to get this location key.
* You now need to know which hourly forecasts (there are 24 in a day and, barring AccuWeather borking their forecasts, as sometimes happens, only three of those are used for in-game weather, at 8 hour intervals, starting…  some time - and only careful observation can help you figure out those times. Or just pick some times that are 8 hours apart and most of the time your forecast will be correct).

##### A little bit about how AccuWeather’s hourly forecasts work, and how Niantic uses them:
A new forecast for the next 8 hours (after the hour it is posted - so a forecast posted at noon will cover 1pm through 12 am) is available at the top of each hour, but this forecast may be updated throughout that hour.  Generally speaking, only the first three hours of an hourly forecast will be changed when it is updated - the rest of the forecast will largely stay the same - except for about once a day, very early in the day (I dunno? Maybe 02:00 UTC? Or thereabouts?). This is really only a problem if this happens to be the hour that Niantic draws from, and you think it’s the hour before. This is when AccuWeather is also updating their long-range forecast (more than 12 hours away). 

Niantic uses the forecast from near the start of the hour (not right at the hour change, but I think around quarter-past the hour) for the following 8 hours. I know this from observation, because sometimes AccuWeather updates the forecast later in the hour as well, and those changes end up not being reflected in the in-game weather. At least, this is true in my location. YMMV.

Because only the first three hours of a forecast get updated (99% of the time), if you keep careful hourly records of every forecast and compare those to in-game weather using the translation model I’ve developed, you can figure out when the pull times are (on days when the forecast changes a lot, anyway; on days when it stays static, you’re out of luck). This method is how I confirmed the 8 hour pull times.

In order to accurately record and analyse the weather in-game compared to forecasts, I have pulled hourly forecasts for a year, and whenever possible, compared the in-game weather to those forecasts. I’ve used this method to nail down the translations, and also to figure out at which point weather becomes windy. I have not yet been able to do this for any location other than Lindsay, Ontario, so I have no idea, really, if pull-times are global or local, or exactly how big weather cells are. I built a .NET web app/api (because I am a .NET developer and so I know it best) that takes care of pulling hourly forecasts, displaying those forecasts on a web page to allow me to figure out the pull times - I do this by marking a forecast as incorrect and then using a drop-down to indicate the correct in-game weather, set the pull times using my own API, and then use those pull times to post thrice-daily in-game forecasts to our local Discord server. I also included Pokedex info and a list of current raid bosses, so when it posts the forecast, it includes which raid bosses are boosted. The web portal also displays a list of all raid bosses, indicating the boosted ones, and showing current max CP (also shows types and which bosses have the potential to be shiny). Among other things. It’s a messy, messy work in progress, with abandoned avenues all over the damned place. As soon as I have time (ugh, between the game and a full-time job, this ain’t easy), I will clean up the code and post it on GitHub. I promise.

##### For weather conversion:
I have great confidence in this model. Usually, when there is a discrepancy, it’s either because I haven’t actually seen that particular forecast icon before and I’d guessed in the model, OR Niantic changed the pull time.

Wind took me the longest to figure out, but since my last change to my code, I’ve successfully predicted windy weather 100% of the time when the pull time was also correct. Windy is tricky because it doesn’t use the icon id/text (unless it’s the windy icon). Instead, it uses wind speed and wind gust speed. Often, the icon portion of the forecast will not change from hour to hour, but specific measurements WILL change, so this was harder to observe. Also, **only certain weather can become windy.** “Mostly Cloudy w/ Showers” will give you a cloudy weather boost in-game (with rain effect visually but no rain boost) and cannot become windy (although if it’s windy, you may also see in-game wind effect). “Dreary (Overcast)” also shows up as a cloudy weather boost but CAN become windy. *shrugs* It is windy (in Lindsay, Ontario, anyway)  if the current boost is windy-able (if it can be overridden by wind) AND if either of the following is true: the wind speed is greater than 24 km/h OR the wind gust speed is greater than 35 km/h.

I live in southern/central Ontario, Canada, so we’ve yet to see a forecast that is either just Hot or Cold. I have no idea what those get translated to, or whether or not they can be windy. Standard disclaimer: your mileage may vary (but these are my observations from over a year of analysis).

## IMPORTANT LINKS
* Get your api key by registering with the [AccuWeather API](https://developer.accuweather.com/)
* Figure out which s2 cell you are in using [this amazing tool](https://s2.sidewalklabs.com/regioncoverer/)
* Once you have the geocoordinates for your cell (and your API key), get the location id using [this AccuWeather Location API](https://developer.accuweather.com/accuweather-locations-api/apis/get/locations/v1/cities/geoposition/search)
* Learn about Discord webhooks [here](https://support.discordapp.com/hc/en-us/articles/228383668-Intro-to-Webhooks)

##### One last note:
This is a port of a much bigger app that I use for my own Discord, which includes pokedex info and posts boosted bosses along with boosted types. I tried to clean up all of the extraneous stuff and pare this down to just what was required, but I know I've missed a few things here and there. I will tidy it all up as I have time.

As a very good friend of mine often says...
  *Godspeed, little doodles*