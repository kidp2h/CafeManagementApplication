

namespace CafeManagementApplication.controllers
{
    class LoadPanelController
    {
        private static LoadPanelController instance;
        public static LoadPanelController Instance
        {
            get
            {
                if (instance == null) instance = new LoadPanelController();
                return instance;
            }
        }

        private dynamic view;
        public dynamic View
        {
            get { return view; }
            set { view = value; }
        }
        public void LoadingInfoProduct(string name, string price, string tag)
        {
            this.view.LblNameText= name;
            this.view.LblNameTag = tag;
            this.view.LblPriceText = price;
        }
    }
}
