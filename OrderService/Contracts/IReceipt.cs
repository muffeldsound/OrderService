namespace OrderService.Contracts
{
    interface IReceipt
    {
        string GenerateReceipt(Order order);
    }
}
