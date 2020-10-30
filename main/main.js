module.exports = function main() {

    var queryCount=inputs.reduce(function(r,v){
        r.set(v.Name,(r.get(v.Name)||0)+1);
        return r;
        },new Map());
    
        var queryPrice=inputs.reduce(function(r,v){
            r.set(v.Name,v.Price);
            return r;
        },new Map('',0.00));
        
        var queryUnit=inputs.reduce(function(r,v){
            r.set(v.Name,v.Unit);
            return r;
        },new Map());
    
        var itemName=new Array(); 
        let itemSpecies=0;   
        for (let key of queryCount.keys()) {
            
            itemName[itemSpecies]=key;
            itemSpecies++;
        }
    
        function fetchValues(query,index){
            let queryResult=new Array();
            let itemSpecies=0;
            for (let value of query.values()){
                
                queryResult[itemSpecies]=value;
                itemSpecies++;
            }
            return queryResult;
        }
        var itemCount=fetchValues(queryCount,1,itemCount);
        var itemPrice=fetchValues(queryPrice,2,itemPrice);
        var itemUnit=fetchValues(queryUnit,3,itemUnit);
        var text='***<store earning no money>Receipt ***\n';
        for(let i=0;i<itemName.length;i++)
        {
            if (itemCount[i]>1){
                text+='Name: '+itemName[i]+
                ', Quantity: '+itemCount[i]+' '+itemUnit[i]+
                's, UnitPrice: '+itemPrice[i].toFixed(2)+' (yuan),'+
                ' Subtotal: '+itemPrice[i].toFixed(2)*itemCount[i]+' (yuan)\n';
            }
            else{
                text+='Name: '+itemName[i]+
                ', Quantity: '+itemCount[i]+
                ', UnitPrice: '+itemPrice[i].toFixed(2)+' (yuan),'+
                ' Subtotal: '+itemPrice[i].toFixed(2)*itemCount[i]+' (yuan)\n';
            }
           
        }
    
        function ComputeTotalPrice(count,price){
            var totalPrice=0.00;
            for (let i=0;i<count.length;i++)
            {
                 var totalPrice=totalPrice+count[i]*price[i];
            }
             return totalPrice;
        };
        var total=ComputeTotalPrice(itemCount,itemPrice);
        text+='----------------------\n' +
        'Total: '+total.toFixed(2)+' (yuan)\n' +
        '**********************\n';
    
        return text;
};
