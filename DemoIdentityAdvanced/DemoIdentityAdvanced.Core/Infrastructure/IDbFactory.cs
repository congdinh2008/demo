using DemoIdentityAdvanced.UI.Models;
using System;

namespace DemoIdentityAdvanced.Core.Infrastructure
{
    public interface IDbFactory: IDisposable
    {
        ApplicationDbContext Init();
    }
}
