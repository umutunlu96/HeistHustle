using System;
using Extentions;
using Keys;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public Action onInteractSkillUsed;
        public Action onInvisibleSkillUsed;
        public Action onDashSkillUsed;
        public Action onRunSkillUsed;
        public Action onRunSkillRevoked;
        public Action<InputParams> onInputTaken;
    }
}