using System;

namespace ComicsUniverse.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
