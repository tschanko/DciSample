using Adapters.Persistence;
using Domain.UseCases.TransferMoney;
using NServiceBus;

namespace Adapters.Transport
{
   
    public class EndpointConfiguration 
    {
        public static void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.DiscardFailedMessagesInsteadOfSendingToErrorQueue();
            var conventions = configuration.Conventions();
            conventions.DefiningCommandsAs(p => p.Name.EndsWith("Command"));

            var roleRoutingTable = CreateRoutingTable();
            
            configuration.RegisterComponents(c => {
                c.RegisterSingleton(roleRoutingTable);
                c.ConfigureComponent<NsbRoleRouter>(DependencyLifecycle.InstancePerUnitOfWork);
                c.ConfigureComponent<AccountRepositoryMock>(DependencyLifecycle.InstancePerUnitOfWork);
            });
        }

        static RoleRoutingTable CreateRoutingTable()
        {
            var rt = new RoleRoutingTable();
            rt.RegisterRoute(typeof(ITransferMoneySource), "EndpointA");
            rt.RegisterRoute(typeof(ITransferMoneySink), "EndpointB");
            return rt;
        }
    }
}
