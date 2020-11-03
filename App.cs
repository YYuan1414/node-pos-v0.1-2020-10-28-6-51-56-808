namespace TakeOutFood
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security.Cryptography.X509Certificates;

    public class App
    {
        private IItemRepository itemRepository;
        private ISalesPromotionRepository salesPromotionRepository;

        public App(IItemRepository itemRepository, ISalesPromotionRepository salesPromotionRepository)
        {
            this.itemRepository = itemRepository;
            this.salesPromotionRepository = salesPromotionRepository;
        }

        public string BestCharge(List<string> inputs)
        {
            var sale = salesPromotionRepository.FindAll();
            var saleItems = sale[0].RelatedItems;

            var AllItems = itemRepository.FindAll();
            List<string> saleId = new List<string>();
            List<string> unSaleId = new List<string>();

            double totalPrice = 0;

            string result = "============= Order details =============\n";
            foreach (string orderString in inputs)
            {
                var itemId = orderString.Substring(0, 8);
                var itemNumber = orderString.Substring(11, 1);
                for (int i = 0; i < saleItems.Count; i++)
                {
                    var saleItem = saleItems[i];

                    if (saleItem == itemId)
                    {
                        saleId.Add(itemId + itemNumber);
                        break;
                    }
                    else if (saleItem != itemId)
                    {
                        unSaleId.Add(itemId + itemNumber);
                        break;
                    }
                }
            }

            foreach (Item item in AllItems)
            {
                foreach (string requiredSaledItem in saleId)
                {

                    var itemSaledNumber = int.Parse(requiredSaledItem.Substring(8, 1));
                    
                    if (requiredSaledItem.Substring(0, 8) == item.Id)
                    {
                        
                        result = result + item.Name + " x " + itemSaledNumber + " = " + item.Price* itemSaledNumber + " yuan\n";
                        totalPrice += item.Price * 0.5* itemSaledNumber;
                        break;
                    }
                }
                foreach (string requiredUnSaledItem in unSaleId)
                {

                    var itemNumber = int.Parse(requiredUnSaledItem.Substring(8, 1));

                    if (requiredUnSaledItem.Substring(0, 8) == item.Id)
                    {
                        result = result + item.Name + " x " + itemNumber + " = " + item.Price*itemNumber + " yuan\n";
                        totalPrice += item.Price * itemNumber;
                        break;
                    }
                }
            }
            foreach (Item item in AllItems)
            {
                result += "Promotion used:\n";
                foreach (string requiredSaledItem in saleId)
                {

                    var itemSaledNumber = int.Parse(requiredSaledItem.Substring(8, 1));

                    if (requiredSaledItem.Substring(0, 8) == item.Id)
                    {
                        result = result + item.Name + " x " + itemSaledNumber + " = " + item.Price * itemSaledNumber * 0.5 + " yuan\n";
                        totalPrice += item.Price * 0.5 * itemSaledNumber;
                        break;
                    }
                }
                
            }

            return result;
        }
    }
}
