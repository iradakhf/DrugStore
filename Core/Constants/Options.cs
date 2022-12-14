using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum Options1
    {
        Exit,
        CreateOwner,
        UpdateOwner,
        RemoveOwner,
        GetOwner,
        GetAllOwners
    }
    public enum Options2
    {
        Exit,
        CreateDrugStore,
        UpdateDrugStore,
        RemoveDrugStore,
        GetDrugStore,
        GetAllDrugStores,
        GetAllDrugStoresByOwner,
        Sale,
        GetTheBudget
    }
    public enum Options3
    {
        Exit,
        CreateDruggist,
        UpdateDruggist,
        RemoveDruggist,
        GetDruggist,
        GetAllDruggists,
            GetAllDruggistByDrugStore


    }
    public enum Options4
    {
        Exit,
        CreateDrug,
        UpdateDrug,
        RemoveDrug,
        GetDrug,
        GetAllDrugs,
        GetAllDrugsByDrugStore,
        Filter
    }

}
