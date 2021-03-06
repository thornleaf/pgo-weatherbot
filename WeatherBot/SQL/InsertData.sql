USE [WeatherBot]
GO
SET IDENTITY_INSERT [dbo].[PgoWeathers] ON 
GO
INSERT [dbo].[PgoWeathers] ([Id], [Description], [FileName], [IsDay], [IsNight], [Friendly]) VALUES (1, N'Fog', N'weatherIcon_small_fog.png', 1, 1, N'fog')
GO
INSERT [dbo].[PgoWeathers] ([Id], [Description], [FileName], [IsDay], [IsNight], [Friendly]) VALUES (2, N'Rain', N'weatherIcon_small_rain.png', 1, 1, N'rain')
GO
INSERT [dbo].[PgoWeathers] ([Id], [Description], [FileName], [IsDay], [IsNight], [Friendly]) VALUES (3, N'Snow', N'weatherIcon_small_snow.png', 1, 1, N'snow')
GO
INSERT [dbo].[PgoWeathers] ([Id], [Description], [FileName], [IsDay], [IsNight], [Friendly]) VALUES (4, N'Clear', N'weatherIcon_small_clear.png', 0, 1, N'sunny-clear')
GO
INSERT [dbo].[PgoWeathers] ([Id], [Description], [FileName], [IsDay], [IsNight], [Friendly]) VALUES (5, N'Sunny', N'weatherIcon_small_sunny.png', 1, 0, N'sunny-clear')
GO
INSERT [dbo].[PgoWeathers] ([Id], [Description], [FileName], [IsDay], [IsNight], [Friendly]) VALUES (6, N'Windy', N'weatherIcon_small_windy.png', 1, 1, N'windy')
GO
INSERT [dbo].[PgoWeathers] ([Id], [Description], [FileName], [IsDay], [IsNight], [Friendly]) VALUES (7, N'Cloudy', N'weatherIcon_small_cloudy.png', 1, 1, N'cloudy')
GO
INSERT [dbo].[PgoWeathers] ([Id], [Description], [FileName], [IsDay], [IsNight], [Friendly]) VALUES (8, N'Partly Cloudy (Day)', N'weatherIcon_small_partlycloudy_day.png', 1, 0, N'partly-cloudy')
GO
INSERT [dbo].[PgoWeathers] ([Id], [Description], [FileName], [IsDay], [IsNight], [Friendly]) VALUES (9, N'Partly Cloudy (Night)', N'weatherIcon_small_partlycloudy_night.png', 0, 1, N'partly-cloudy')
GO
SET IDENTITY_INSERT [dbo].[PgoWeathers] OFF
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (1, N'Sunny', 1, 1, 0, 5, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (2, N'Mostly Sunny', 1, 1, 0, 5, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (3, N'Partly Sunny', 1, 1, 0, 8, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (4, N'Intermittent Clouds', 1, 1, 0, 8, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (5, N'Hazy Sunshine', 1, 1, 0, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (6, N'Mostly Cloudy', 1, 1, 0, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (7, N'Cloudy', 1, 1, 1, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (8, N'Dreary (Overcast)', 1, 1, 1, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (11, N'Fog', 0, 1, 1, 1, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (12, N'Showers', 0, 1, 1, 2, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (13, N'Mostly Cloudy w/ Showers', 0, 1, 0, 7, 22)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (14, N'Partly Sunny w/ Showers', 0, 1, 0, 8, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (15, N'T-Storms', 0, 1, 1, 2, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (16, N'Mostly Cloudy w/ T-Storms', 0, 1, 0, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (17, N'Partly Sunny w/ T-Storms', 0, 1, 0, 8, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (18, N'Rain', 0, 1, 1, 2, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (19, N'Flurries', 0, 1, 1, 3, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (20, N'Mostly Cloudy w/ Flurries', 0, 1, 0, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (21, N'Partly Sunny w/ Flurries', 0, 1, 0, 8, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (22, N'Snow', 0, 1, 1, 3, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (23, N'Mostly Cloudy w/ Snow', 0, 1, 0, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (24, N'Ice', 0, 1, 1, 3, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (25, N'Sleet', 0, 1, 1, 3, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (26, N'Freezing Rain', 0, 1, 1, 2, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (29, N'Rain and Snow', 0, 1, 1, 2, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (30, N'Hot', 1, 1, 1, 5, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (31, N'Cold', 1, 1, 1, 3, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (32, N'Windy', 1, 1, 1, 6, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (33, N'Clear', 1, 0, 1, 4, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (34, N'Mostly Clear', 1, 0, 1, 4, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (35, N'Partly Cloudy', 1, 0, 1, 9, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (36, N'Intermittent Clouds', 1, 0, 1, 9, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (37, N'Hazy Moonlight', 1, 0, 1, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (38, N'Mostly Cloudy', 1, 0, 1, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (39, N'Partly Cloudy w/ Showers', 0, 0, 1, 9, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (40, N'	Mostly Cloudy w/ Showers', 0, 0, 1, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (41, N'Partly Cloudy w/ T-Storms', 0, 0, 1, 9, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (42, N'Mostly Cloudy w/ T-Storms
', 0, 0, 1, 7, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (43, N'Mostly Cloudy w/ Flurries', 0, 0, 1, 3, 24)
GO
INSERT [dbo].[WeatherTranslations] ([Id], [IconText], [CanWindy], [IsDay], [IsNight], [PgoIconId], [WindOverrideVal]) VALUES (44, N'Mostly Cloudy w/ Snow', 0, 0, 1, 3, 24)
GO
SET IDENTITY_INSERT [dbo].[PokemonTypes] ON 
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (1, N'Normal', N'#8a8a59')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (2, N'Fighting', N'#c03028')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (3, N'Flying', N'#a890f0')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (4, N'Poison', N'#a040a0')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (5, N'Ground', N'#e0c068')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (6, N'Rock', N'#b8a038')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (7, N'Bug', N'#a8b820')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (8, N'Ghost', N'#705898')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (9, N'Steel', N'#5598a3')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (10, N'Fire', N'#f08030')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (11, N'Water', N'#6890f0')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (12, N'Grass', N'#78c850')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (13, N'Electric', N'#f8d030')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (14, N'Psychic', N'#f85888')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (15, N'Ice', N'#98d8d8')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (16, N'Dragon', N'#0876bf')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (17, N'Dark', N'#705848')
GO
INSERT [dbo].[PokemonTypes] ([Id], [Name], [Color]) VALUES (18, N'Fairy', N'#e898e8')
GO
SET IDENTITY_INSERT [dbo].[PokemonTypes] OFF
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (1, 8)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (1, 9)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (2, 7)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (3, 6)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (4, 7)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (5, 4)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (5, 5)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (6, 8)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (6, 9)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (7, 2)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (8, 1)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (9, 3)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (10, 4)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (10, 5)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (11, 2)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (12, 4)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (12, 5)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (13, 2)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (14, 6)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (15, 3)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (16, 6)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (17, 1)
GO
INSERT [dbo].[WeatherTypes] ([TypeId], [WeatherId]) VALUES (18, 7)
GO
