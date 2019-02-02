'use strict';

// Declare app level module which depends on views, and components
angular.module('pokeTools', [
    'ngResource',
    'ngRoute',
    //'pokeTools.home',
    'pokeTools.weather',
    'ui.bootstrap'
])

    .config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
        $routeProvider.otherwise({ redirectTo: '/bosses' });
    }])
    .run(['$rootScope', '$location', '$http', function ($rootScope, $location, $http) {
        var host = $location.host();
        //$http.default.headers.common['Accept'] = 'application/json';
        localStorage.setItem('baseUrl', '');
    }])
    .factory('httpResponseInterceptor', ['$q', '$rootScope', '$location', function ($q, $rootScope, $location) {
        return {
            response: function (response) {
                return response;
            },
            responseError: function (rejection) {
                if (rejection.status === 401) {
                    $rootScope.logout();
                }
                return $q.reject(rejection);
            }
        };
    }])
    .factory('RestService', ['$resource', function ($resource) {
        var baseUrl = localStorage.getItem('baseUrl');
        if (baseUrl.indexOf('localhost') > -1 || !baseUrl || baseUrl === "") {
            //baseUrl = 'http://weatherbot.thornleaf.net/';
        }
        console.log('Base URL: ' + baseUrl);
        return $resource(baseUrl + 'api/:ext1/:ext2',
            { ext1: '@ext1', ext2: '@ext2' },
            {
                putArray: { method: 'PUT', isArray: true },
                saveArray: { method: 'POST', isArray: true }
            }
        );
    }])
    .filter('padleft', function () {
        return function (a) {
            if (a === undefined) {
                return 'xxx';
            }
            var b = a.toString();
            if (b.length === 3) {
                return b;
            } else if (b.length === 2) {
                return '0' + b;
            } else {
                return '00' + b;
            }
        };
    })
    .controller('IndexController', ['$scope', '$rootScope', '$http', 'RestService', function ($scope, $rootScope, $http, RestService) {
        $rootScope.currentUser = JSON.parse(sessionStorage.getItem('currentUser'));

        $scope.login = function (c) {
            //var authString = 'Basic ' + Base64.encode(c.username + ':' + c.password);
            //console.log(authString);
            //$http.defaults.headers.common['Authorization'] = authString;
            RestService.save({ ext1: 'login' }, c, function (m) {
                $scope.closeModal('#loginModal');
                $rootScope.currentUser = m;
                sessionStorage.setItem('currentUser', JSON.stringify(m));
                //sessionStorage.setItem('authString', authString);
            }, function (e) {
                $scope.error = true;
                });
        };
        $rootScope.logout = function () {
            RestService.get({ ext1: 'login' }, function () {
                // logged out!
            })
            //delete $http.defaults.headers.common['Authorization'];
            delete $rootScope.currentUser;
            sessionStorage.clear();
        };
        $scope.closeModal = function (id) {
            $(id).modal('hide');
        };
    }])
    ;