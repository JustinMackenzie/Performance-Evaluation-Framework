using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScenarioSim.Server.Models;

namespace ScenarioSim.Server.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ScenarioSim.Server.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ScenarioSim.Server.Models.ApplicationDbContext context)
        {
            CreateRole(context, "Performer");
            CreateRole(context, "Scenario Author");
            CreateRole(context, "Evaluator");
            CreateRole(context, "Curriculum Designer");
            CreateRole(context, "Administrator");

            CreateUser(context, "testPerformer@uwo.ca", "test123", new List<string> { "Performer" });
        }

        private void CreateRole(ApplicationDbContext context, string roleName)
        {
            if (!context.Roles.Any(r => r.Name == roleName))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = roleName };

                manager.Create(role);
            }
        }

        private void CreateUser(ApplicationDbContext context, string username, string password,
            IEnumerable<string> roles)
        {
            if (!context.Users.Any(u => u.UserName == username))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = username };

                manager.Create(user, password);

                foreach (string role in roles)
                    manager.AddToRole(user.Id, role);
            }
        }
    }
}
