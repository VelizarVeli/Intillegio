﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Intillegio.Common.Constants;
using Intillegio.DTOs.BindingModels.Admin;
using Intillegio.DTOs.BindingModels.ViewModels;
using Intillegio.Models;
using Intillegio.Services.Contracts;
using Intillegio.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class TeamMembersController : BaseController
    {
        private readonly IAboutService _aboutService;
        private readonly UserManager<IntillegioUser> _currentUser;

        public TeamMembersController(IAboutService aboutService, UserManager<IntillegioUser> currentUser)
        {
            _aboutService = aboutService;
            _currentUser = currentUser;
        }

        public IActionResult TeamMembers()
        {
            var allTeamMembersForAdmin = _aboutService.GetTeamMembersForAdmin();

            return View(GlobalConstants.AdminAreaPath + "TeamMembers/TeamMembers.cshtml", allTeamMembersForAdmin);
        }

        public IActionResult AddTeamMember()
        {
            var listActivityies = new List<ActivityAndSkill>();
            listActivityies.Add(new ActivityAndSkill{Name = "Good"});
            listActivityies.Add(new ActivityAndSkill{Name = "Bad"});
            listActivityies.Add(new ActivityAndSkill{Name = "Fuck"});
            listActivityies.Add(new ActivityAndSkill{Name = "Person"});
            listActivityies.Add(new ActivityAndSkill{Name = "Motherfucker"});
            listActivityies.Add(new ActivityAndSkill{Name = "You"});

            var model = new AdminTeamMemberBindingModel
            {
                ActivitiesAndSkills = listActivityies
            };

            return View(GlobalConstants.AdminAreaPath + "TeamMembers/AddTeamMember.cshtml", model);
        }
        public IActionResult AddTeamMember2()
        {
            var  model = new AdminTeamMemberBindingModel();

            return View(GlobalConstants.AdminAreaPath + "TeamMembers/AddTeamMember2.cshtml", model);
        }
        [HttpPost]
        public string AddTeamMember2(AdminTeamMemberBindingModel model)
        {
            var sb = new StringBuilder();
            try
            {
                sb.AppendFormat("Author : {0}", model.Name);
                sb.AppendLine("<br />");
                sb.AppendLine("--------------------------------");
                sb.AppendLine("<br />");
                foreach (var book in model.ActivitiesAndSkills)
                {
                    sb.AppendFormat("Title : {0}", book.Name);
                    sb.AppendLine("<br />");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sb.ToString();
        }


        [HttpPost]
        public async Task<IActionResult> AddTeamMember(AdminTeamMemberBindingModel model)
        {
            await _aboutService.AddTeamMemberAsync(model);

            return RedirectToAction("TeamMembers");
        }

        public async Task<IActionResult> TeamMemberDetails(int id)
        {
            var teamMemberDetails = await _aboutService.GetTeamMemberDetailsForAdminAsync(id);

            if (teamMemberDetails == null)
            {
                return RedirectToAction(ActionConstants.TeamMembers);
            }

            return View("TeamMemberDetails", teamMemberDetails);
        }

        public async Task<IActionResult> DeleteTeamMemberDetails(int id)
        {
            var deleteDetails = await _aboutService.GetTeamMemberDetailsForAdminAsync(id);

            return View("DeleteTeamMember", deleteDetails);
        }

        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            await _aboutService.DeleteTeamMemberAsync(id);
            return RedirectToAction("TeamMembers");
        }
    }
}