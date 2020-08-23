namespace Marketplace.Application.Core
{
    public interface IResponse<In, Out>
    {
        Out Create(In input);
    }
}
