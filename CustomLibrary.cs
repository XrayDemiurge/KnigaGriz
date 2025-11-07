using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace Проект_Нежурин_Дакуко__Бибилотека_
{
    // TODO: добавьте следующее к определению SomeType, чтобы видеть этот визуализатор при отладке экземпляров SomeType:
    // 
    //  [DebuggerVisualizer(typeof(CustomLibrary))]
    //  [Serializable]
    //  public class SomeType
    //  {
    //   ...
    //  }
    // 
    /// <summary>
    /// Визуализатор для SomeType.  
    /// </summary>
    public class CustomLibrary : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
                throw new ArgumentNullException("windowService");
            if (objectProvider == null)
                throw new ArgumentNullException("objectProvider");

            // TODO: получите объект, для которого нужно отобразить визуализатор.
            //       Выполните приведение результата objectProvider.GetObject() 
            //       к типу визуализируемого объекта.
            object data = (object)objectProvider.GetObject();

            // TODO: отобразите свое представление объекта.
            //       Замените displayForm на свой объект Form или Control.
            using (Form displayForm = new Form())
            {
                displayForm.Text = data.ToString();
                windowService.ShowDialog(displayForm);
            }
        }

        // TODO: добавьте следующее к своему коду тестирования для тестирования визуализатора:
        // 
        //    CustomLibrary.TestShowVisualizer(new SomeType());
        // 
        /// <summary>
        /// Тестирует визуализатор, разместив его вне отладчика.
        /// </summary>
        /// <param name="objectToVisualize">Объект для отображения в визуализаторе.</param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(CustomLibrary));
            visualizerHost.ShowVisualizer();
        }
    }
}
