using Domain.NServiceBus;
using Domain.UseCases.TransferMoney;
using NServiceBus;

namespace EndpointB
{
    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            EndpointConfiguration.Customize(configuration);
        }

       
    }
}
