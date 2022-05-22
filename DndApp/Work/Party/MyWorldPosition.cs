using Nez;

namespace DndApp;

public class MyWorldPosition : Component, ITriggerListener
{
    private Splotch _lastSplotch;

    private Biome _lastBiome;
    //collision result
    #region ITriggerListener implementation
    public Biome InsideBiome { get; set; }

    // public static Biome _lastBiome { get; set; }
    private Splotch LastSplotch
    {
        get => _lastSplotch;
        set
        {
            _lastSplotch = value;
            _lastBiome = _lastSplotch.GetComponent<Biome>();
        }
    }

    void ITriggerListener.OnTriggerEnter(Collider other, Collider self)
    {
        var splotch = (Splotch)other.Entity;
        var biome = splotch.GetComponent<Biome>();
        if (LastSplotch != null)
        {
            if (_lastBiome.Name.Equals(biome.Name))
                return;
            if (LastSplotch.RenderLayer < splotch.RenderLayer)
                return;
        }
        LastSplotch = splotch;
        InsideBiome = biome;
    }
    void ITriggerListener.OnTriggerExit(Collider other, Collider self) { /*Debug.Log("triggerExit: {0}", other.Entity.Name);*/}
    #endregion
}