using QFramework;

namespace Entitas {

    public class ContextStillHasRetainedEntitiesException : ExceptionWithHint {

        public ContextStillHasRetainedEntitiesException(IContext context)
            : base("'" + context + "' detected retained entities " +
                "although all entities got destroyed!",
                "Did you release all entities? Try calling systems.ClearReactiveSystems()" +
                "before calling context.DestroyAllEntities() to avoid memory leaks.") {
        }
    }
}
