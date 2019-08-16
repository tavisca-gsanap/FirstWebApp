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

			string(	name: 'DOCKER_IMAGE_NAME',
					defaultValue: "webapi3", 
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
        stage('Publish') {
            steps {
                sh 'dotnet publish ${SOLUTION_FILE_PATH} -o publish' 
            }
        }
        stage('Deploy'){
		     steps{
                sh '''
				if(docker inspect -f {{.State.Running}} ${DOCKER_CONTAINER})
				then
					docker container rm -f ${DOCKER_CONTAINER}
				fi
			    '''
                sh 'docker build -t ${DOCKER_IMAGE_NAME} -f Dockerfile .'
				sh 'docker run --name ${DOCKER_CONTAINER_NAME} -p 57539:57539 ${DOCKER_IMAGE_NAME}:latest'
                sh 'docker image rm -f ${DOCKER_IMAGE_NAME}:latest'
			 }
		}
    }
}