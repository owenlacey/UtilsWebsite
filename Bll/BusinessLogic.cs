using Bll.Services;
using Bll.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class BusinessLogic : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            //services
            Bind(typeof(IBaseService<>)).To(typeof(BaseService<>));
            Bind<IMealsService>().To<MealsService>();
        }
    }
}
