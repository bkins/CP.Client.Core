using System.Threading.Tasks;

namespace CP.Client.Core.Avails
{
    public static class TaskExtensions
    {
        public static void FireAndForget (this Task task)
        {
            Shared.Primitives.Avails.Extensions.TaskExtensions.FireAndForget(task);
        }
    }
}