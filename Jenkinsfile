pipeline {
    agent any
	parameters {	
            choice(
                    choices: ['BUILD' , 'TEST' , 'PUBLISH','RUN_ON_DOCKER','DEPLOY_TO_DOCKER'],
                    name: 'CHOSEN_ACTION')	

			string(	name: 'GIT_SSH_PATH',
					defaultValue: "https://github.com/tavisca-gsanap/FirstWebApp.git")

			string(	name: 'SOLUTION_FILE_PATH',
					defaultValue: "FirstWebApp.sln")

			string(	name: 'TEST_PROJECT_PATH',
					defaultValue: "FirstWebAppTest/FirstWebAppTest.csproj")

			string(	name: 'DOCKER_IMAGE_NAME',
					defaultValue: "webapi3")

			string(	name: 'DOCKER_CONTAINER_NAME',
					defaultValue: "webapi3")

			string(	name: 'DOCKER_USERNAME',
					defaultValue: "gsanap")

			string(	name: 'DOCKER_PASSWORD',
					defaultValue: "password")

			string(name: 'DOCKER_REPOSITORY',
			       defaultValue: 'webapi_demo')
    }
	
    stages {
        stage('Build') {
            steps {
				sh 'dotnet restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org/v3/index.json'
                sh 'dotnet build  ${SOLUTION_FILE_PATH} -p:Configuration=release -v:q'
            }
        }
        stage('Test') {
            when 
            {
                expression {params.CHOSEN_ACTION=='TEST' ||  params.CHOSEN_ACTION=='PUBLISH'||  params.CHOSEN_ACTION=='RUN_ON_DOCKER' ||  params.CHOSEN_ACTION=='DEPLOY_TO_DOCKER'}
            }
            steps {
                sh 'dotnet test ${TEST_PROJECT_PATH}' 
            }
        }
        stage('Publish') {
            when 
            {
                expression {params.CHOSEN_ACTION=='PUBLISH'||  params.CHOSEN_ACTION=='RUN_ON_DOCKER' ||  params.CHOSEN_ACTION=='DEPLOY_TO_DOCKER'}
            }
            steps {
                sh 'dotnet publish ${SOLUTION_FILE_PATH} -o publish' 
            }
        }
        stage('Run'){
            when 
            {
                expression {params.CHOSEN_ACTION=='RUN_ON_DOCKER'}
            }
		     steps{
                sh '''
				if(docker inspect -f {{.State.Running}} ${DOCKER_CONTAINER_NAME})
				then
					docker container rm -f ${DOCKER_CONTAINER_NAME}
				fi
			    '''
                sh 'docker build -t ${DOCKER_IMAGE_NAME} -f Dockerfile .'
				sh 'docker run --name ${DOCKER_CONTAINER_NAME} -d -p 57539:57539 ${DOCKER_IMAGE_NAME}:latest'
                sh 'docker image rm -f ${DOCKER_IMAGE_NAME}:latest'
			 }
		}
        stage('Deploy'){
            when 
            {
                expression {params.CHOSEN_ACTION=='DEPLOY_TO_DOCKER'}
            }
            steps{
                sh 'docker build -t ${DOCKER_IMAGE_NAME} -f Dockerfile .'
                sh 'docker tag ${DOCKER_IMAGE_NAME} ${DOCKER_USERNAME}/${DOCKER_REPOSITORY}:latest'
				sh 'docker login -u ${DOCKER_USERNAME} -p ${DOCKER_PASSWORD}'
				sh 'docker push ${DOCKER_USERNAME}/${DOCKER_REPOSITORY}:latest'
                sh 'docker image rm -f ${DOCKER_IMAGE_NAME}:latest'
            }
        }
    }
    post{
        always{
            deleteDir()
        }
    }
}