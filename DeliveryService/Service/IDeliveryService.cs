using DeliveryService.Model;

namespace DeliveryService.Service
{
    public interface IDeliveryService
    {
        void StartListening();
        DeliveryPartner GetAvailablePartner();
    }
}
