using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern
{
    internal class FactoryMethod
    {
        
        abstract class HiringManager
        {
            abstract protected IInterviewer MakeInterviewer();
            public void TakeInterview()
            {
                var interviewer = this.MakeInterviewer();
                interviewer.AskQuestions();
            }
            class MarktingManager : HiringManager 
            {
                protected override IInterviewer MakeInterviewer()
                {
                    return new CommunityExecutive();

                }
            }


        }
    }
}
