using WDE.Module.Attributes;
using WDE.QueryGenerators.Base;
using WDE.QueryGenerators.Models;
using WDE.SqlQueryGenerator;

namespace WDE.QueryGenerators.Generators.Creature;

[AutoRegister]
internal class CreatureDeleteQueryProvider : IDeleteQueryProvider<CreatureSpawnModelEssentials>
{
    public IQuery Delete(CreatureSpawnModelEssentials t)
    {
        return Queries.Table("creature")
            .Where(row => row.Column<uint>("guid") == t.Guid)
            .Delete();
    }
}