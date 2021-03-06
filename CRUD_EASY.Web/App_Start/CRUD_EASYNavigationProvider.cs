﻿using Abp.Application.Navigation;
using Abp.Localization;
using CRUD_EASY.Authorization;

namespace CRUD_EASY.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class CRUD_EASYNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", CRUD_EASYConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                        )

                           .AddItem(
                    new MenuItemDefinition(
                        "Candidato",
                        new LocalizableString("Candidato", CRUD_EASYConsts.LocalizationSourceName),
                        url: "#/candidato",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                        )

                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "#users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )));
                //).AddItem(
                //    new MenuItemDefinition(
                //        "Roles",
                //        L("Roles"),
                //        url: "#users",
                //        icon: "fa fa-tag",
                //        requiredPermissionName: PermissionNames.Pages_Roles
                //    )
                //)
                //.AddItem(
                //    new MenuItemDefinition(
                //        "About",
                //        new LocalizableString("About", CRUD_EASYConsts.LocalizationSourceName),
                //        url: "#/about",
                //        icon: "fa fa-info"
                //        )
                //);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CRUD_EASYConsts.LocalizationSourceName);
        }
    }
}
