using GenerateCrudWithDapper.Core.Dto;
using System;

namespace GenerateCrudWithDapper.Core.Utils
{
    internal static class FlagExecuteUtils
    {
        public static void Execute(CrudGenerateDto dto, Action action)
        {
            if (dto.GenerateUtils)
                action.Invoke();
        }
    }
}
