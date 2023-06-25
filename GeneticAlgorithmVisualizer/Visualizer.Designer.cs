namespace GeneticAlgorithmVisualizer
{
    partial class Visualizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMapCreate = new System.Windows.Forms.Button();
            this.TravelMap = new System.Windows.Forms.Panel();
            this.buttonDotPoints = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonRandRoute = new System.Windows.Forms.Button();
            this.labelGeneration = new System.Windows.Forms.Label();
            this.labelBestDistance = new System.Windows.Forms.Label();
            this.labelSelectedDistance = new System.Windows.Forms.Label();
            this.labelBDText = new System.Windows.Forms.Label();
            this.buttonRouteMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMapCreate
            // 
            this.buttonMapCreate.Location = new System.Drawing.Point(12, 45);
            this.buttonMapCreate.Name = "buttonMapCreate";
            this.buttonMapCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonMapCreate.TabIndex = 0;
            this.buttonMapCreate.Text = "Create Map";
            this.buttonMapCreate.UseVisualStyleBackColor = true;
            this.buttonMapCreate.Click += new System.EventHandler(this.buttonMapCreate_Click);
            // 
            // TravelMap
            // 
            this.TravelMap.Location = new System.Drawing.Point(93, 46);
            this.TravelMap.Name = "TravelMap";
            this.TravelMap.Size = new System.Drawing.Size(401, 401);
            this.TravelMap.TabIndex = 1;
            // 
            // buttonDotPoints
            // 
            this.buttonDotPoints.Location = new System.Drawing.Point(12, 74);
            this.buttonDotPoints.Name = "buttonDotPoints";
            this.buttonDotPoints.Size = new System.Drawing.Size(75, 23);
            this.buttonDotPoints.TabIndex = 2;
            this.buttonDotPoints.Text = "Dot Points";
            this.buttonDotPoints.UseVisualStyleBackColor = true;
            this.buttonDotPoints.Click += new System.EventHandler(this.buttonDotPoints_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 424);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonRandRoute
            // 
            this.buttonRandRoute.Location = new System.Drawing.Point(12, 103);
            this.buttonRandRoute.Name = "buttonRandRoute";
            this.buttonRandRoute.Size = new System.Drawing.Size(75, 23);
            this.buttonRandRoute.TabIndex = 4;
            this.buttonRandRoute.Text = "Rand Route";
            this.buttonRandRoute.UseVisualStyleBackColor = true;
            this.buttonRandRoute.Click += new System.EventHandler(this.buttonRandRoute_Click);
            // 
            // labelGeneration
            // 
            this.labelGeneration.AutoSize = true;
            this.labelGeneration.Location = new System.Drawing.Point(90, 6);
            this.labelGeneration.Name = "labelGeneration";
            this.labelGeneration.Size = new System.Drawing.Size(62, 13);
            this.labelGeneration.TabIndex = 5;
            this.labelGeneration.Text = "Generation:";
            // 
            // labelBestDistance
            // 
            this.labelBestDistance.AutoSize = true;
            this.labelBestDistance.Location = new System.Drawing.Point(90, 22);
            this.labelBestDistance.Name = "labelBestDistance";
            this.labelBestDistance.Size = new System.Drawing.Size(76, 13);
            this.labelBestDistance.TabIndex = 6;
            this.labelBestDistance.Text = "Best Distance:";
            // 
            // labelSelectedDistance
            // 
            this.labelSelectedDistance.AutoSize = true;
            this.labelSelectedDistance.Location = new System.Drawing.Point(227, 22);
            this.labelSelectedDistance.Name = "labelSelectedDistance";
            this.labelSelectedDistance.Size = new System.Drawing.Size(97, 13);
            this.labelSelectedDistance.TabIndex = 7;
            this.labelSelectedDistance.Text = "Selected Distance:";
            // 
            // labelBDText
            // 
            this.labelBDText.AutoSize = true;
            this.labelBDText.Location = new System.Drawing.Point(172, 22);
            this.labelBDText.Name = "labelBDText";
            this.labelBDText.Size = new System.Drawing.Size(0, 13);
            this.labelBDText.TabIndex = 8;
            // 
            // buttonRouteMap
            // 
            this.buttonRouteMap.Location = new System.Drawing.Point(12, 132);
            this.buttonRouteMap.Name = "buttonRouteMap";
            this.buttonRouteMap.Size = new System.Drawing.Size(75, 23);
            this.buttonRouteMap.TabIndex = 9;
            this.buttonRouteMap.Text = "Route Map";
            this.buttonRouteMap.UseVisualStyleBackColor = true;
            this.buttonRouteMap.Click += new System.EventHandler(this.buttonRouteMap_Click);
            // 
            // Visualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 459);
            this.Controls.Add(this.buttonRouteMap);
            this.Controls.Add(this.labelBDText);
            this.Controls.Add(this.labelSelectedDistance);
            this.Controls.Add(this.labelBestDistance);
            this.Controls.Add(this.labelGeneration);
            this.Controls.Add(this.buttonRandRoute);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonDotPoints);
            this.Controls.Add(this.TravelMap);
            this.Controls.Add(this.buttonMapCreate);
            this.Name = "Visualizer";
            this.Text = "Visualizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMapCreate;
        private System.Windows.Forms.Panel TravelMap;
        private System.Windows.Forms.Button buttonDotPoints;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonRandRoute;
        private System.Windows.Forms.Label labelGeneration;
        private System.Windows.Forms.Label labelBestDistance;
        private System.Windows.Forms.Label labelSelectedDistance;
        private System.Windows.Forms.Label labelBDText;
        private System.Windows.Forms.Button buttonRouteMap;
    }
}

