

namespace App_Hexagonal.Application.Common.UseCase
{
    public interface IUseCase<in TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);

    }
    // public interface IUseCase<in TRequest>
    // {
    //     Task ExecuteAsync(TRequest request);
    // }

    // public interface IUseCase<out TResponse>
    // {
    //     Task<TResponse> ExecuteAsync();
    // }

}