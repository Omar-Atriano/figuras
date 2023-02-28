using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figuras
{
    public class Scene
    {
        private Figures figure;
        public Pen pen = new Pen(Color.White);
        public int angle;


        public Scene(Figures figures)
        {
            figure = figures;
        }

        public void Draw(Graphics graphics, int viewWidth, int viewHeight, bool rotX, bool rotY, bool rotZ)
        {
            graphics.Clear(Color.FromArgb(0, 0, 0));

            // Draw x-axis
            graphics.DrawLine(new Pen(Color.Gray), 0, viewHeight / 2, viewWidth, viewHeight / 2);

            // Draw y-axis
            graphics.DrawLine(new Pen(Color.Gray), viewWidth / 2, 0, viewWidth / 2, viewHeight);

            var projected = new Vertex[figure.Vertices.Length];
            for (var i = 0; i < figure.Vertices.Length; i++)
            {
                var vertex = figure.Vertices[i];

                //var transformed = vertex.RotateX(angle).RotateY(angle).RotateZ(angle);
                var transformed = vertex;
                //var transformed = vertex.RotateX(angle);

                if (rotX && rotY && rotZ)
                {
                    transformed = vertex.RotateX(angle).RotateY(angle).RotateZ(angle);
                }
                else if (rotX && rotY && !rotZ)
                {
                    transformed = vertex.RotateX(angle).RotateY(angle);
                }
                else if (rotX && !rotY && rotZ)
                {
                    transformed = vertex.RotateX(angle).RotateZ(angle);
                }
                else if (rotX && !rotY && !rotZ)
                {
                    transformed = vertex.RotateX(angle);//check
                }
                else if (!rotX && rotY && !rotZ)
                {
                    transformed = vertex.RotateY(angle);
                }
                else if (!rotX && !rotY && rotZ)
                {
                    transformed = vertex.RotateZ(angle);
                }
                else if (!rotX && rotY && rotZ)
                {
                    transformed = vertex.RotateY(angle).RotateZ(angle);
                }

                projected[i] = transformed.Project(viewWidth, viewHeight, 256, 6);
            }

            for (var j = 0; j < 6; j++)
            {
                graphics.DrawLine(pen,
                    (int)projected[figure.Faces[j, 0]].X,
                    (int)projected[figure.Faces[j, 0]].Y,
                    (int)projected[figure.Faces[j, 1]].X,
                    (int)projected[figure.Faces[j, 1]].Y);

                graphics.DrawLine(pen,
                    (int)projected[figure.Faces[j, 1]].X,
                    (int)projected[figure.Faces[j, 1]].Y,
                    (int)projected[figure.Faces[j, 2]].X,
                    (int)projected[figure.Faces[j, 2]].Y);

                graphics.DrawLine(pen,
                    (int)projected[figure.Faces[j, 2]].X,
                    (int)projected[figure.Faces[j, 2]].Y,
                    (int)projected[figure.Faces[j, 3]].X,
                    (int)projected[figure.Faces[j, 3]].Y);

                graphics.DrawLine(pen,
                    (int)projected[figure.Faces[j, 3]].X,
                    (int)projected[figure.Faces[j, 3]].Y,
                    (int)projected[figure.Faces[j, 0]].X,
                    (int)projected[figure.Faces[j, 0]].Y);
            }
            angle++;
        }
    }
}
