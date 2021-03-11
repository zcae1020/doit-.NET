using System;

namespace doit_study_homework_template
{
    public class HW01 : homework
    {
        /* Dont Touch */
        public bool isRunning { get;  set; }
        public HW01(bool _isRunning){
            isRunning = _isRunning;
        }
        /********************/
        public void main(){
            /* 여기에 코드를 작성하세요 */
            Console.WriteLine("Hello World!");
        }
    }
}