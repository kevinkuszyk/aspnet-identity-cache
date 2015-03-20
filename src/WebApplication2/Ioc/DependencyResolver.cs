using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Ninject;
using Ninject.Parameters;
using Ninject.Web.Common;
using WebApplication2.Models;

namespace WebApplication2.Ioc
{
    public sealed class DependencyResolver
    {
        private static volatile DependencyResolver instance;
        private static readonly object syncRoot = new Object();
        private readonly IKernel kernel;

        private DependencyResolver()
        {
            kernel = new StandardKernel();

            RegisterServices();
        }

        /// <summary>
        /// The singleton instance of the dependency resolver.
        /// </summary>
        public static DependencyResolver Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DependencyResolver();
                        }
                    }
                }

                return instance;
            }
        }

        internal IKernel Kernel { get { return kernel; } }
        
        /// <summary>
        /// Gets an instance of the specified service.
        /// </summary>
        public T Get<T>()
        {
            return kernel.Get<T>();
        }
        
        private void RegisterServices()
        {
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            var dbContext = kernel.Get<ApplicationDbContext>();
            kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().WithConstructorArgument("context", dbContext);

            kernel.Bind<IAuthenticationManager>().ToMethod(x => HttpContext.Current.GetOwinContext().Authentication);
        }
}}