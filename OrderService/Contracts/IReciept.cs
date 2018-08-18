namespace OrderService.Contracts
{
    interface IReciept
    {
        string GenerateReceipt(Order order);
    }
}
