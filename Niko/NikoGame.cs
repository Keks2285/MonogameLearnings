using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Niko
{
    public class NikoGame : Game
    {


        string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $@"Save.txt");
        //string contentPath = System.Forms.Application.StartupPath + "\\" + Content.RootDirectory;
        int x = 0;
        int y = 0;
        string entered="X";
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Texture2D texture;       
        Button ButtonUp = new Button();
        SpriteFont font;
        ActivityMain activity;
       
       // var name = KeyboardInput.Show();;

        public NikoGame()
        {
           
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";           
            var metric = new Android.Util.DisplayMetrics();
            Activity.WindowManager.DefaultDisplay.GetMetrics(metric);
            // установка параметров экрана
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = metric.WidthPixels;
            graphics.PreferredBackBufferHeight = metric.HeightPixels;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            //IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           // x = ReadSave();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("F");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("testimage");
            ButtonUp.TextureButton = Content.Load<Texture2D>("Up");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //if (a) counter++;
            // if (!a) counter--;
            //if (counter > 50) a = false;
            //if (counter < -50) a = true;
            // TODO: Add your update logic here
            if (ButtonUp.IsPressed)
            {


                readKeyboardasync("Титульник","Описание","Строка", false);// вызов клавиатуры


                //entered = KeyboardInput.Show("Name", "What's your name?", "Player").Result;
                //if (n.Result != null)
                //    entered = n.Result;
                ////if (KeyboardInput.IsVisible == false) 
                //{
                //    using (StreamWriter sw = new StreamWriter(file, true, System.Text.Encoding.Default))
                //    {
                //        sw.WriteLine(name);
                //    }
                //} 
                // readKeyboardasync();
            }
            else { }
            //if (entered != "") x = Convert.ToInt32(entered);
          

           // entered = name.Result;
            base.Update(gameTime);
        }

        private int ReadSave()
        {
            int X = 0;
          
              //if (File.Exists(file)) { File.Delete(file); }

            if (!File.Exists(file))
            {
                using (FileStream fs = File.Create(file)) { }

                using (StreamWriter sw = new StreamWriter(file, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(100);
                }
            }

            using (StreamReader sr = new StreamReader(file, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    X = Convert.ToInt32(line);
                }
            }
            return X;
        }

        private async Task readKeyboardasync(string title, string description, string defaultstrng, bool passwordmode)
        {
   
            entered= await KeyboardInput.Show(title, description, defaultstrng, passwordmode);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
          //  if (entered != "") x = 100;
            spriteBatch.Draw(texture, new Rectangle(x,y, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
            Color.White);
            spriteBatch.DrawString(font,@$"Score: {entered}", new Vector2(100, 100), Color.White);




            // spriteBatch.Draw(texture, new Vector2(0, 0),null, Color.White,0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
            //spriteBatch.Draw(texture,new Vector2(0,0),
            // new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), 
            // Color.White,0,Vector2.Zero,0.8f,SpriteEffects.None,0);
            ButtonUp.Process(spriteBatch,5, graphics.PreferredBackBufferHeight-200,200,200 );
            //ButtonUp.Update(90, 205);
            

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
