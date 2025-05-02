// <copyright file="TheEscapeButtonForm.cs" company="AlexMagikov">
// Copyright (c) AlexMagikov. All rights reserved.
// </copyright>

namespace TheEscapeButton;

using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

/// <summary>
/// The Escape Button form.
/// </summary>
public partial class TheEscapeButtonForm : Form
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TheEscapeButtonForm"/> class.
    /// </summary>
    public TheEscapeButtonForm()
    {
        this.InitializeComponent();
        this.MinimumSize = new Size(this.escapeButton.Size.Width * 2, this.escapeButton.Top);
        this.Resize += this.OnFormResize;
    }

    private void OnButtonClick(object sender, EventArgs e)
    {
        this.Close();
    }

    private void OnMouseEnter(object sender, EventArgs e)
    {
        this.escapeButton.Left = Random.Shared.Next(0, this.ClientSize.Width - this.escapeButton.Width);
        this.escapeButton.Top = Random.Shared.Next(0, this.ClientSize.Height - this.escapeButton.Height);
    }

    private void OnFormResize(object? sender, EventArgs e)
    {
        int maxX = Math.Max(0, this.ClientSize.Width - this.escapeButton.Width);
        int maxY = Math.Max(0, this.ClientSize.Height - this.escapeButton.Height);

        this.escapeButton.Left = Math.Clamp(this.escapeButton.Left, 0, maxX);
        this.escapeButton.Top = Math.Clamp(this.escapeButton.Top, 0, maxY);
    }
}
