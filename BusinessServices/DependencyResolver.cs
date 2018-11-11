using System.ComponentModel.Composition;
using DataModel;
using DataModel.UnitOfWork;
using Resolver;

namespace BusinessServices
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IRegistroServices, RegistroServices>();
            registerComponent.RegisterType<IItemServices, ItemServices>();
            registerComponent.RegisterType<IUsuarioServices, UsuarioServices>();
            registerComponent.RegisterType<IGrupoServices, GrupoServices>();
            registerComponent.RegisterType<IConductorServices, ConductorServices>();
        }
    }
}
