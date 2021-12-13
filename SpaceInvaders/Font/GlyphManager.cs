using System;
using System.Xml;

namespace SpaceInvaders.Font
{
    class GlyphManager : Manager.Manager
    {
        //Singleton instantiation 
        private static int RESERVE_SIZE = 3;
        private static int GROWTH_SIZE = 2;
        private static GlyphManager instance = new GlyphManager(RESERVE_SIZE, GROWTH_SIZE);

        //Compare node
        private readonly Glyph poNodeCompare = null;

        //---------------------------------------------------------------------------------------------------------
        // Class Methods
        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reserveSize">Size of the reserve list</param>
        /// <param name="growthSize">Growth size</param>
        private GlyphManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new Glyph();
        }

        /// <summary>
        /// Returns isntatnce of the manager
        /// </summary>
        /// <returns>Instatnce of the manager</returns>
        public static GlyphManager GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Destroys the manager and its resrouces
        /// </summary>
        public static void Destroy()
        {
            BaseDestroy(instance);
            GlyphManager.instance = null;
        }

        public Glyph Add(Glyph.Name name, int key, TextureNode.Name textName, float x, float y, float width, float height)
        {
            Glyph pNode = (Glyph)BaseAdd();

            pNode.Set(name, key, textName, x, y, width, height);
            return pNode;
        }

        public void AddXml(Glyph.Name glyphName, String assetName, TextureNode.Name textName)
        {
            System.Xml.XmlTextReader reader = new XmlTextReader(assetName);

            int key = -1;
            int x = -1;
            int y = -1;
            int width = -1;
            int height = -1;

            // I'm sure there is a better way to do this... but this works for now
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.GetAttribute("key") != null)
                        {
                            key = Convert.ToInt32(reader.GetAttribute("key"));
                        }
                        else if (reader.Name == "x")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    x = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "y")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    y = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "width")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    width = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "height")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    height = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element 
                        if (reader.Name == "character")
                        {
                            // have all the data... so now create a glyph
                            //Debug.WriteLine("key:{0} x:{1} y:{2} w:{3} h:{4}", key, x, y, width, height);
                            instance.Add(glyphName, key, textName, x, y, width, height);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Finds a texture node by name
        /// </summary>
        /// <param name="name">Name of the texture node to find</param>
        /// <returns>Texture node coresponding to the name. Null if no such texture was found</returns>
        public Glyph Find(Glyph.Name name, int key)
        {
            instance.poNodeCompare.name = name;
            instance.poNodeCompare.key = key;

            Glyph pNode = (Glyph)BaseFind(instance.poNodeCompare);
            return pNode;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override Methods
        //---------------------------------------------------------------------------------------------------------
        protected override DLink GetBlank()
        {
            return new Glyph();
        }

        protected override bool CompareNodes(DLink nodeA, DLink nodeB)
        {
            Glyph compNodeA = (Glyph)nodeA;
            Glyph compNodeB = (Glyph)nodeB;

            bool match = false;

            if (compNodeA.name == compNodeB.name && compNodeA.key == compNodeB.key) match = true;

            return match;
        }

        protected override void Wash(DLink pNode)
        {
            Glyph pToWash = (Glyph)pNode;
            pToWash.Wash();
        }
    }
}
