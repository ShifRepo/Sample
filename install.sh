wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1 -y
cd FastBite.Tests
rm -rf bin
dotnet build
cd bin
wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb
sudo dpkg -i google-chrome-stable_current_amd64.deb
wget https://chromedriver.storage.googleapis.com/90.0.4430.2400/chromedriver_linux64.zip
unzip chromedriver_linux64.zip 
rm -rf chromedriver_linux64.zip 
cd