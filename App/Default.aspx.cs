using Bondaries.Persistence;
using Core.Boundaries;
using Core.Model;
using Core.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace App
{
    public partial class _Default : Page
    {
        public int ActiveUser { get; set; }
        public int TotalTask { get; set; }
        public string Message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            using (TodoListContext context = new TodoListContext())
            {
                ITaskRepository taskRepo = new EFTaskRepository(context);
                ISystemInfoRepository sysRepo = new EFSystemInfoRepository();

                LoadLandingPageData useCase = new LoadLandingPageData(taskRepo, sysRepo);
                User theuser = new User { UserId = 1 };

                LandingPageData data = useCase.GetData(theuser);

                ActiveUser = data.ActiveUsers;
                TotalTask = data.TotalTasks;


                //var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["ToDoListStr"];
                //using (SqlConnection dbConnection = new SqlConnection(connectionFromConfiguration.ConnectionString))
                //{
                //    try
                //    {
                //        dbConnection.Open();
                //        Message = "Connection Succesfull";

                //    }
                //    catch (SqlException ex)
                //    {
                //        Message = "connection failed";
                //    }


                //}
            }

        }
    }
}