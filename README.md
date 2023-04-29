# WEBP Image Compressor
WEBP Image Compressor is a lightweight and efficient image compression tool that automatically monitors a folder, 
resizes and converts JPEG images to the modern WEBP format. The application reduces file size while maintaining high image quality. 


## Features
- Monitors a specified folder for new JPEG images
- Resizes images based on user-defined maximum dimensions
- Converts images to WEBP format with user-defined compression percentage

## Dependencies
- .NET Framework 4.7.2 or later
- ImageSharp (For image resizing)
- Magick.NET (For image conversion)

## How to use
- Clone the repository or download the source code.
- Open the solution in Visual Studio.
- Install the required NuGet packages (ImageSharp and Magick.NET) if not already installed.
- Build the solution.

Run the application. It will open the monitored folder and show the current default values for maximum dimension and compression percentage.
You can change the default values by following the prompts.
Add JPEG images to the monitored folder. The application will automatically detect new images, resize them, and convert them to WEBP format.
The resized JPEG images and converted WEBP images will be saved in separate subfolders within the monitored folder.
Press 'q' to stop the application and clear the directories.

## Potential improvements

- Support for additional image formats (e.g., PNG, BMP, GIF)
- Option to choose output image format (e.g., JPEG, PNG, or GIF) along with WEBP
- Configurable options for resizing method, aspect ratio, and other image processing parameters
- GUI for easier user interaction
- Real-time monitoring of multiple folders
- Command-line interface for batch processing
- Integration with cloud storage services for automatic backup and sharing

## License
This project is open-source and available under the MIT License.

Feel free to contribute, report any issues, or suggest new features through the GitHub repository. Your feedback and contributions are greatly appreciated.

## Contributing
- Fork the repository on GitHub.
- Clone your fork to your local machine.
- Create a new branch for your changes: git checkout -b your-feature-branch.
- Make your changes and commit them with a descriptive commit message.
- Push your changes to your fork on GitHub: git push origin your-feature-branch.
- Create a new pull request through the GitHub interface.
- We will review your changes and, if appropriate, merge them into the main repository.

## Support
If you encounter any issues or have questions, feel free to open an issue on GitHub or contact the project maintainers. I will do my best to address your concerns.

Thank you for using WEBP Image Compressor!
