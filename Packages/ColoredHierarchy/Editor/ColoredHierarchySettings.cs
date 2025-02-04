using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ColoredHierarchy
{
	public class ColoredHierarchySettings : ScriptableObject
	{
		public bool isEnabled = true;
		public bool DrawBackground = true;
		public bool drawActivationToggle = true;

		public List<ColorDesign> colorDesigns = new List<ColorDesign>();

		// private void OnValidate()
		// {
		// 	Debug.Log("SO OnValidate Çalıştı");
		// 	StyleHierarchy.Initialize();
		// }

		public ColorDesign GetColorDesign(string keyChar)
		{
			foreach (ColorDesign colorDesign in colorDesigns)
			{
				if (colorDesign.keyChar.Equals(keyChar))
					return colorDesign;
			}
			return null;
		}

		[MenuItem("Tools/Colored Hierarchy/Setup ColoredHierarchySettings")]
		public static void Setup()
		{
			string pathPrefix = "Assets/Colored Hierarchy";
			string path = "/ColoredHierarchySettings.asset";
			Directory.CreateDirectory(pathPrefix);

			ColoredHierarchySettings asset = CreateInstance<ColoredHierarchySettings>();
			AssetDatabase.CreateAsset(asset, pathPrefix + path);
			ResetAndLoadInitialSettings(asset);
			StyleHierarchy.Initialize();
		}

		public static void ResetAndLoadInitialSettings(ColoredHierarchySettings asset)
		{
			asset.colorDesigns.Clear();
			asset.colorDesigns.Add(new ColorDesign("1", new Color32(0, 125, 255, 255), new Color32(255, 255, 255, 255), TextAnchor.MiddleCenter, FontStyle.Bold));
			asset.colorDesigns.Add(new ColorDesign("2", new Color32(0, 140, 70, 255), new Color32(255, 255, 255, 255), TextAnchor.MiddleCenter, FontStyle.Bold));
			asset.colorDesigns.Add(new ColorDesign("3", new Color32(255, 100, 0, 255), new Color32(255, 255, 255, 255), TextAnchor.MiddleCenter, FontStyle.Bold));
			asset.colorDesigns.Add(new ColorDesign("4", new Color32(255, 255, 0, 255), new Color32(0, 0, 0, 255), TextAnchor.MiddleCenter, FontStyle.Bold));
			asset.colorDesigns.Add(new ColorDesign("5", new Color32(0, 255, 255, 255), new Color32(0, 0, 0, 255), TextAnchor.MiddleCenter, FontStyle.Bold));
			asset.colorDesigns.Add(new ColorDesign("6", new Color32(255, 0, 255, 255), new Color32(0, 0, 0, 255), TextAnchor.MiddleCenter, FontStyle.Bold));

		}
	}

	[System.Serializable]
	public class ColorDesign
	{
		[Tooltip("Rename gameObject begin with this keychar")]
		public string keyChar;
		[Tooltip("Don't forget to change alpha to 255")]
		public Color backgroundColor;
		[Tooltip("Don't forget to change alpha to 255")]
		public Color textColor;
		public TextAnchor textAlignment;
		public FontStyle fontStyle;

		public ColorDesign(string keyChar, Color backgroundColor, Color textColor, TextAnchor textAlignment, FontStyle fontStyle)
		{
			this.keyChar = keyChar;
			this.backgroundColor = backgroundColor;
			this.textColor = textColor;
			this.textAlignment = textAlignment;
			this.fontStyle = fontStyle;
		}
	}
}
