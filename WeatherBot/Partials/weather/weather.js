
'use strict';

angular.module('pokeTools.weather', ['ngRoute'])
    .config(['$routeProvider', function ($routeProvider) {
        var baseUrl = localStorage.getItem('baseUrl');
        $routeProvider
            .when('/weather', { templateUrl: 'Partials/weather/current.html', controller: 'WeatherController' });
    }])
    .controller('WeatherController', ['$scope', '$interval', '$http', '$filter', 'RestService', function ($scope, $interval, $http, $filter, RestService) {

        $scope.correctVals = [true, false, null];
        $scope.saveValue = function (id, isC) {
            RestService.get({ ext1: 'WeatherVal', ext2: id, isCorrect: isC }, function () {
                $scope.getHist();
            });
        };
        $scope.getPgoWeathers = function () {
            RestService.query({ ext1: 'WeatherVal' }, function (w) {
                $scope.weatherOptions = w;
            });
        };
        $scope.getPgoWeathers();
        $scope.saveActual = function (w) {
            RestService.save({ ext1: 'weatherval' }, w, function () {
                $scope.getHist();
            });
        };
        $scope.delHist = function (id, val) {
            if (val === true) {
                RestService.save({ ext1: 'WeatherVal', ext2: id, del: true }, function (v) {
                    $scope.getHist();
                });
            }
        };
        $scope.getClass = function (v) {
            switch (v) {
                case (v < 22):
                    return 'text-success';
                case (v >= 22 && v < 24):
                    return 'text-warning';
                case (v >= 24):
                    return 'text-danger';
                default:
                    return null;
            }
        };
        $scope.gw = {};
        $scope.get = false;

        $scope.forceWeather = function () {
            var now = new Date();
            var min = now.getMinutes();
            var hour = now.getHours();
            console.log('getting weather');
            RestService.get({ ext1: 'weather' }, function (w) {
                $scope.getHist();
            });
        };
        $scope.responses = [];
        $scope.times = [
            { hr: 0, name: '12 am' },
            { hr: 1, name: '1 am' },
            { hr: 2, name: '2 am' },
            { hr: 3, name: '3 am' },
            { hr: 4, name: '4 am' },
            { hr: 5, name: '5 am' },
            { hr: 6, name: '6 am' },
            { hr: 7, name: '7 am' },
            { hr: 8, name: '8 am' },
            { hr: 9, name: '9 am' },
            { hr: 10, name: '10 am' },
            { hr: 11, name: '11 am' },
            { hr: 12, name: '12 pm' },
            { hr: 13, name: '1 pm' },
            { hr: 14, name: '2 pm' },
            { hr: 15, name: '3 pm' },
            { hr: 16, name: '4 pm' },
            { hr: 17, name: '5 pm' },
            { hr: 18, name: '6 pm' },
            { hr: 19, name: '7 pm' },
            { hr: 20, name: '8 pm' },
            { hr: 21, name: '9 pm' },
            { hr: 22, name: '10 pm' },
            { hr: 23, name: '11 pm' }
        ];
        $scope.makeTime = function () {
            return new Date();
        };
        $scope.config = {};
        $scope.baseHour = 7;
        $scope.getConfig = function () {
            RestService.get({ ext1: 'config', ext2: 1 }, function (c) {
                $scope.config.baseHour = c;
                $scope.baseHour = parseInt(c.value);
                console.log($scope.baseHour);
            });
        };
        $scope.getConfig();

        $scope.updateConfig = function (c) {
            RestService.save({ ext1: 'config' }, c, function () {
                $scope.getConfig();
            });
        };

        $scope.getTranslations = function () {
            RestService.get({ ext1: 'translator' }, function (t) {
                $scope.translations = t.translations;
                $scope.pgoWeather = t.pgoWeathers;
            });
        };
        $scope.getTranslations();
        $scope.saveTranslation = function (t) {
            RestService.save({ ext1: 'translator' }, t, function () {
                $scope.getTranslations();
            });
        };
        
        $scope.wq = { histDate: new Date(), hr: 8 };
        $scope.makeTime = function () {
            return new Date();
        };

        $scope.getHist = function (w) {
            $scope.loading = true;
            var config = {
                ext1: 'weather'
            };
            if (w) { config.date = w; } else { config.date = $scope.wq.histDate; }
            console.log('getting weather');
            RestService.query(config, function (w) {
                $scope.loading = false;
                console.log('got weather!');
                $scope.weatherHistory = w;
            }, function () { $scope.loading = false;});
        };
        $scope.getHist();

        $scope.discord = function (hour) {
            if (!hour) {
                RestService.get({ ext1: 'discord' }, function (r) {
                    console.log(r);
                });
            } else {
                RestService.get({ ext1: 'discord', hour: hour }, function (r) {
                    console.log(r);
                });
            }
            
        };
        var stop;
        $scope.doWeatherThing = function () {
            console.log('running weather');
            if (angular.isDefined(stop)) {
                console.log('weather is already running');
                return;
            }

            stop = $interval(function () {
                var now = new Date();
                var min = now.getMinutes();
                var hour = now.getHours();
                var date = now.getDate();
                if ($scope.wq.histDate.getDate() !== date) {
                    $scope.wq.histDate = now;
                }
                if (min === 12) {
                    console.log('getting weather');
                    $scope.getHist();
                } 
            }, 60000);
        };
        $scope.doWeatherThing();
        $scope.colors = function (id) {
            switch (id) {
                case 1:
                    return 'fog';
                case 2:
                    return 'rain';
                case 3:
                    return 'snow';
                case 4:
                    return 'clearNight';
                case 5:
                    return 'clearDay';
                case 6:
                    return 'windy';
                case 7:
                    return 'cloudy';
                case 8:
                    return 'partlyCloudyDay';
                case 9:
                    return 'partlyCloudyNight';
            }
        };
    }]);