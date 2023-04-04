using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using homework9.Model;
using homework9.View;
using homework9.Presenter;
using homework9.Settings;
using homework9.Models;

namespace HomeWork9
{
   class AppService :IAppService
   {
      public void Run()
      {


         var host = Host.CreateDefaultBuilder()
         .ConfigureServices((ctx, srv) =>
         {           
//           srv.AddTransient<IModelData, ModelDataInterval>();
           srv.AddTransient<IModelData, ModelData>();
           srv.AddTransient<IModelDataGenerator, ModelDataGenerator>();
           srv.AddTransient<IModel, Model>();
           srv.AddTransient<IViewMenu, ViewConsoleMenu>();
           srv.AddTransient<IViewGame, ViewConsoleGame>();           
           srv.AddSingleton<IPresenter, Presenter>();
         }).Build();

      ActivatorUtilities.CreateInstance<Presenter>(host.Services).RunGame();
    }
   }
}
