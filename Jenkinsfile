pipeline {
    agent any
	parameters {		
			string(	name: 'GIT_SSH_PATH',
					defaultValue: "https://github.com/tavisca-gsanap/FirstWebApp.git",
					description: '')

			string(	name: 'SOLUTION_FILE_PATH',
					defaultValue: "FirstWebApp.sln", 
					description: '')

			string(	name: 'TEST_PROJECT_PATH',
					defaultValue: "FirstWebAppTest/FirstWebAppTest.csproj", 
					description: '')

            string(	name: 'DEPLOY_PROJECT_PATH',
					defaultValue: "FirstWebApp/Publish/FirstWebApp.dll", 
					description: '')
    }
	
    stages {
        stage('Build') {
            steps {
				sh 'dotnet restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org/v3/index.json'
                sh 'dotnet build  ${SOLUTION_FILE_PATH} -p:Configuration=release -v:q'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test ${TEST_PROJECT_PATH}' 
            }
        }
        stage('Deploy') {
            steps {
                sh 'dotnet publish ${TEST_PROJECT_PATH} -o Publish' 
                sh 'dotnet FirstWebApp/Publish/FirstWebApp.dll'
            }
        }
    }
}