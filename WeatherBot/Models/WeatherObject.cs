using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherBot.Models
{
    public class Temperature
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class RealFeelTemperature
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class WetBulbTemperature
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class DewPoint
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class Speed
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class Direction
    {
        public float Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }

    public class Wind
    {
        public Speed Speed { get; set; }
        public Direction Direction { get; set; }
    }

    public class Speed2
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class WindGust
    {
        public Speed2 Speed { get; set; }
    }

    public class Visibility
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class Ceiling
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class TotalLiquid
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class Rain
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class Snow
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class Ice
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public float UnitType { get; set; }
    }

    public class WeatherObject
    {
        public DateTime DateTime { get; set; }
        public int EpochDateTime { get; set; }
        public int WeatherIcon { get; set; }
        public string IconPhrase { get; set; }
        public bool IsDaylight { get; set; }
        public Temperature Temperature { get; set; }
        public RealFeelTemperature RealFeelTemperature { get; set; }
        public WetBulbTemperature WetBulbTemperature { get; set; }
        public DewPoint DewPoint { get; set; }
        public Wind Wind { get; set; }
        public WindGust WindGust { get; set; }
        public float RelativeHumidity { get; set; }
        public Visibility Visibility { get; set; }
        public Ceiling Ceiling { get; set; }
        public float UVIndex { get; set; }
        public string UVIndexText { get; set; }
        public float PrecipitationProbability { get; set; }
        public float RainProbability { get; set; }
        public float SnowProbability { get; set; }
        public float IceProbability { get; set; }
        public TotalLiquid TotalLiquid { get; set; }
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }
        public Ice Ice { get; set; }
        public float CloudCover { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
        public PgoWeather PokeWeather { get; set; }
    }
    public class WeatherResponse
    {
        public WeatherObject[] Data { get; set; }
    }
}