using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Shared.UI.Services.DialogBox
{

    public interface IDialogServiceBase<T>: ITScope
    {
        Task<T> ShowAsync(string message, string? title = null);
    }


   
}
