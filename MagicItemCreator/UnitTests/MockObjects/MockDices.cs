using MagicItemCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.ErrorManagement;

namespace UnitTests.MockObjects
{
    public class MockDices : IDices
    {
        public List<int> DiceRolls { get; set; }

        private static int currentRoll = 0;

        public MockDices(List<int> preparedRolls)
        {
            currentRoll = 0;
            DiceRolls = preparedRolls;
        }

        public int d100()
        {
            if (DiceRolls == null || DiceRolls.Count == 0)
                throw new UnitTestingException("DiceRolls is empty or null");
            return DiceRolls[currentRoll++ % DiceRolls.Count];
        }
    }
}
