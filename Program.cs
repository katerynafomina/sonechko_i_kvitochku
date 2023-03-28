namespace sonechko_i_kvitochku
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Create objects
            Sun sun = new Sun();
            Flower daisy = new Flower("Маргаритка", "day", 7);
            Flower rose = new Flower("Троянда", "day",10);
            Flower jasmine = new Flower("Жасмин", "night", 9);
            Bee bee1 = new Bee("Бджілка 1");
            Bee bee2 = new Bee("Бджілка 2");
            NightButterfly butterfly1 = new NightButterfly("метелик 1");
            Girl nastya = new Girl("Настя");

            int day = 1;
            //Connect events
            daisy.OnBloom += bee1.CollectNectar;
            rose.OnBloom += bee2.CollectNectar;
            jasmine.OnClose += bee1.CollectNectar;
            daisy.OnClose += butterfly1.DrinkNectar;
            rose.OnClose += butterfly1.DrinkNectar;
            jasmine.OnBloom += butterfly1.DrinkNectar;
            daisy.OnBloom += nastya.smellFlower;
            rose.OnBloom += nastya.smellFlower;
            jasmine.OnBloom += nastya.smellFlower;
            daisy.OnBloom += nastya.takeSelfie;
            rose.OnBloom += nastya.takeSelfie;
            jasmine.OnBloom += nastya.takeSelfie;
            
            

            //nightFlower.Opened += butterfly.Pollinate;
            //nightFlower2.Opened += butterfly.Pollinate;
            //daisy.Wilted += girl.RemoveFlower;
            //rose.Wilted += girl.RemoveFlower;
            ////jasmine.Wilted += girl.RemoveFlower;
            //nightFlower.Wilted += girl.RemoveFlower;
            //nightFlower2.Wilted += girl.RemoveFlower;


            // Run interactions for 10 days
            for (int i = 1;i <= 10; i++)
            {
                day = i;
                Console.WriteLine("\nДень {0} починається.", day);

                // Sun rises
                sun.Rise();

                // Daytime interactions
                Console.WriteLine("\nДенні взаємодії:");

                //jasmine
                jasmine.Update(sun.isDay());

                // Daisy
                daisy.Update(sun.isDay());

                //rose
                rose.Update(sun.isDay());

                nastya.update();

                
                
                // Sun sets
                sun.Set();
                Console.WriteLine("\nНічні взаємодії:");
                // Daisy
                daisy.Update(sun.isDay());

                //rose
                rose.Update(sun.isDay());

                //jasmine
                jasmine.Update(sun.isDay());

                daisy.dayPass();
                rose.dayPass();
                jasmine.dayPass();
                nastya.passDay();
                System.Threading.Thread.Sleep(1000);
            }
        }

    }
}