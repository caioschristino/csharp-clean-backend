using System;

namespace clean_sharp {
    public interface ControllerFactory<V, T>
            where T : class
            where V : class {
        T create(V context);
    }
}