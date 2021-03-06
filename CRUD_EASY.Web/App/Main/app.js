﻿(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
            $locationProvider.hashPrefix('');
            $urlRouterProvider.otherwise('/');
            $qProvider.errorOnUnhandledRejections(false);

            if (abp.auth.hasPermission('Pages.Users')) {
                $stateProvider
                    .state('users', {
                        url: '/users',
                        templateUrl: '/App/Main/views/users/index.cshtml',
                        menu: 'Users' //Matches to name of 'Users' menu in CRUD_EASYNavigationProvider
                    });
                $urlRouterProvider.otherwise('/');
            }

            if (abp.auth.hasPermission('Pages.Roles')) {
                $stateProvider
                    .state('roles', {
                        url: '/roles',
                        templateUrl: '/App/Main/views/roles/index.cshtml',
                        menu: 'Roles' //Matches to name of 'Tenants' menu in CRUD_EASYNavigationProvider
                    });
                $urlRouterProvider.otherwise('/');
            }

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in CRUD_EASYNavigationProvider
                    });
                $urlRouterProvider.otherwise('/');
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in CRUD_EASYNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in CRUD_EASYNavigationProvider
                });


            $stateProvider
                .state('candidato',
                {   url:'/candidato',
                    templateUrl: '/App/Main/views/candidato/create/create.cshtml',
                    menu: 'Candidato'
                });

            $stateProvider
                .state('searchCandidato',
                {
                    url: '/searchCandidato',
                    templateUrl: '/App/Main/views/candidato/search/searchCandidato.cshtml',
                    menu: 'Search'
                });

            $stateProvider
                .state('banco',
                {
                    url: '/banco',
                    templateUrl: '/App/Main/views/candidato/create/createBanco.cshtml'
                    
                });

            $stateProvider
                .state('conhecimento',
                {
                    url: '/conhecimento',
                    templateUrl: '/App/Main/views/candidato/create/createConhecimento.cshtml'

                });

            $stateProvider
                .state('candidatoInfo',
                {
                    url: '/candidatoInfo',
                    templateUrl: '/App/Main/views/candidato/search/candidatoInfo.cshtml'

                });
        }
    ]);

})();