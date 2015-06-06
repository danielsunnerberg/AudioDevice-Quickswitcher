namespace AudioDevice_Quickswitcher.controllers
{

    /// <summary>
    /// Basis for a class which controls a view.
    /// </summary>
    /// <typeparam name="T">Type of view which the controller controls</typeparam>
    class ViewController<T>
    {
        public T View { get; protected set; }
    }
}