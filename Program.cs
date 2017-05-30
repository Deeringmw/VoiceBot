using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace VoiceBotCons
{
    class Program
    {

        static void Main(string[] args)
        {
            SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
           

            Choices commands = new Choices();
            commands.Add(new string[]
            {
              // "newcommand'
              "dkp",
              "test"
            });

            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            //Load Grammar into recognition engine.
            recEngine.LoadGrammarAsync(grammar);
            //set microphone to default system mic.
            recEngine.SetInputToDefaultAudioDevice();

            recEngine.RecognizeAsync(RecognizeMode.Multiple);

            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
            //  \/\/\/DO NOT DELETE THIS! MAKES THE WHOLE THING WORK, IDK\/\/\/\/
            Console.Read();
            //  /\/\/\/DO NOT DELETE THIS! MAKES THE WHOLE THING WORK, IDK\/\/\/\/\
        }

        public static void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "dkp":
                    Console.WriteLine("50 DKP Minus!");
                    break;
                case "test":
                    Console.WriteLine("Printing Test");
                    break;
            }
        }
    }
}
