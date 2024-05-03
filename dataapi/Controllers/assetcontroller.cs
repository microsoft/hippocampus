using DataApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DataApi.Controllers;
public class AssetsController : ODataController
{
    private List<Asset> assets = new();

    private readonly SingletonAssets _singletonAssets;

    public AssetsController(SingletonAssets singletonAssets)
    {
        this._singletonAssets = singletonAssets;
        this.assets = this._singletonAssets.Assets;
    }

    [EnableQuery]
    public ActionResult<IEnumerable<Asset>> Get()
    {
        return this.Ok(this.assets);
    }

    [EnableQuery]
    public ActionResult<Asset> Get([FromRoute] int key)
    {
        var item = this.assets.SingleOrDefault(d => d.AccountNumber.Equals(key));

        if (item == null)
        {
            return this.NotFound();
        }

        return this.Ok(item);
    }
}

