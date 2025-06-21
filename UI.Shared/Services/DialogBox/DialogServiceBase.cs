using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Shared.Services.DialogBox
{

    public interface IDialogServiceBase
    {
        /// <summary>
        /// دالة عامة لعرض حوار/نافذة حوار مع رسالة أو محتوى نصي.
        /// </summary>
        /// <param name="message">النص أو الرسالة التي تظهر في الحوار.</param>
        /// <param name="title">عنوان الحوار (اختياري).</param>
        /// <returns>يمكن أن ترجع نتيجة (مثلاً true/false/nullable حسب نوع الحوار).</returns>
        Task<bool?> Show(string message, string? title = null);
    }

    public class DialogServiceBase
    {
    }
}
