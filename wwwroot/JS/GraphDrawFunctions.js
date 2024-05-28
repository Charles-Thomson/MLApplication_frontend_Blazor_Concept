var CurrentChart;
function drawMazeEnvironment(EnvironmentDimension, startLocationData,goalsLocationData, ObsticalsLocationData) {
    var ctx = document.getElementById('myChart').getContext('2d');

    var ScatterData = {
        datasets: [{
            label: "Goal Node",
            data: goalsLocationData,
            backgroundColor: 'rgb(255, 255, 0)',
            showLine: false,
            pointStyle: 'star',
            radius: 15,
        },
        {
            label: "Obs Node",
            data: ObsticalsLocationData,
            backgroundColor: 'rgb(136, 8, 8) ',
            showLine: false,
            pointStyle: 'circle',
            radius: 15,
        },
        {
            label: "Start  Node",
            data: startLocationData,
            backgroundColor: 'rgb(255, 99, 0)',
            showLine: false,
            pointStyle: 'star',
            radius: 15,
            borderWidth: 4
        }
        ],
    };

    var chartConfig = {
        type: 'scatter',
        data: ScatterData,
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: EnvironmentDimension,
                        reverse: true,
                        stepSize: 1
                    }
                }],
                xAxes: [{
                    ticks: {
                        min: 0,
                        max: EnvironmentDimension,
                        
                        stepSize: 1 
                    }
                }]
            }
        }
    };

    if (CurrentChart) {
        CurrentChart.destroy();
        CurrentChart = new Chart(ctx, chartConfig);
    } else {
        CurrentChart = new Chart(ctx, chartConfig);
    }
}
function drawEnvironment() {
    var ctx = document.getElementById('myChart').getContext('2d');

    EnvironmentDimension = 10;

    var EmptyDataSet = {
        datasets: [
        
        ],
    };

    var chartConfig = {
        type: 'scatter',
        data: EmptyDataSet,
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: EnvironmentDimension,
                        stepSize: 1
                    }
                }],
                xAxes: [{
                    ticks: {
                        min: 0,
                        max: EnvironmentDimension,
                        stepSize: 1
                    }
                }]
            }
        }
    };

    if (CurrentChart) {
        CurrentChart.destroy();
        CurrentChart = new Chart(ctx, chartConfig);
    } else {
        CurrentChart = new Chart(ctx, chartConfig);
    }   
}

/// Plot the agent path

function DrawAgentPath(AgentPath, StartLocationData,GoalLocations,  ObsticalLocations, EnvironmentDimension) {

    var ctx = document.getElementById('myChart');

    var ScatterData = {
        datasets: [{
            label: "Path Node",
            data: AgentPath,
            backgroundColor: 'transparent',
            showLine: true,
            pointStyle: 'triangle',
            radius: 5,
        }, {
                label: "Goal Node",
            data: GoalLocations,

                backgroundColor: 'rgb(255, 255, 0)',
                showLine: false,
                pointStyle: 'star',
                radius: 15,
            },
            {
                label: "Obs Node",
                data: ObsticalLocations,

                backgroundColor: 'rgb(136, 8, 8) ',
                showLine: false,
                pointStyle: 'circle',
                radius: 15,
            },
            {
                label: "Start  Node",
                data: StartLocationData,

                backgroundColor: 'rgb(255, 99, 0)',
                showLine: false,
                pointStyle: 'star',
                radius: 15,
                borderWidth: 4
            }
        ],
    };

    var chartConfig = {
        type: 'scatter',
        data: ScatterData,
        tension: 0.2,
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: EnvironmentDimension,
                        reverse: true,
                        stepSize: 1
                    }
                }],
                xAxes: [{
                    ticks: {
                        min: 0,
                        max: EnvironmentDimension,
                        
                        stepSize: 1
                    }
                }]
            }
        }
    };

    if (CurrentChart) {
        CurrentChart.destroy();
        CurrentChart = new Chart(ctx, chartConfig);
    } else {
        CurrentChart = new Chart(ctx, chartConfig);
    }

};

function generateList(n) {
    let list = [];
    for (let i = 0; i <= n; i++) {
        list.push(i);
    }
    return list;
}

// Taken out the data for testing
// Just sort out the passing of the fintess by step data 
function DrawFitnessByStep(fitnessByStepData) {

    var ctx = document.getElementById('myChart');

    var newLabels = generateList(fitnessByStepData.length);

    var data = {
        labels: newLabels,
        datasets: [{
            label: 'My First Dataset',
            data: fitnessByStepData,
            fill: false,
            borderColor: 'rgb(75, 192, 192)',
            tension: 0.1
        }]
    };

    var chartConfig = {
        type: 'line',
        data: data, // Plug data in here
        options: {
            scales: {
                xAxes: {
                    title: {
                        display: true,
                        text: 'Step'
                    }
                },
                yAxes: {
                    title: {
                        display: true,
                        text: 'Fitness'
                    }
                }
            }
        }
    };

    if (CurrentChart) {
        CurrentChart.destroy();
        CurrentChart = new Chart(ctx, chartConfig);
    } else {
        CurrentChart = new Chart(ctx, chartConfig);
    }

};

function DrawGenerationAllAgentsFitnessResults(PlottingData_List) {

    var ctx = document.getElementById('myChart');

    var newLabels = generateList(PlottingData_List.length);

    var data = {
        labels: newLabels,
        datasets: [{
            label: 'My First Dataset',
            data: PlottingData_List,
            fill: false,
            borderColor: 'rgb(75, 192, 192)',
            tension: 0.1
        }]
    };

    var chartConfig = {
        type: 'line',
        data: data, // Plug data in here
        options: {
            scales: {
                xAxes: {
                    title: {
                        display: true,
                        text: 'Step'
                    }
                },
                yAxes: {
                    title: {
                        display: true,
                        text: 'Fitness'
                    }
                }
            }
        }
    };

    if (CurrentChart) {
        CurrentChart.destroy();
        CurrentChart = new Chart(ctx, chartConfig);
    } else {
        CurrentChart = new Chart(ctx, chartConfig);
    }

};

function DrawInstanceGenerationsAverageFitnessProgression(PlottingData_List) {

    var ctx = document.getElementById('myChart');

    var newLabels = generateList(PlottingData_List.length);

    var data = {
        labels: newLabels,
        datasets: [{
            label: 'My First Dataset',
            data: PlottingData_List,
            fill: false,
            borderColor: 'rgb(75, 192, 192)',
            tension: 0.1
        }]
    };

    var chartConfig = {
        type: 'line',
        data: data, // Plug data in here
        options: {
            scales: {
                xAxes: {
                    title: {
                        display: true,
                        text: 'Step'
                    }
                },
                yAxes: {
                    title: {
                        display: true,
                        text: 'Fitness'
                    }
                }
            }
        }
    };

    if (CurrentChart) {
        CurrentChart.destroy();
        CurrentChart = new Chart(ctx, chartConfig);
    } else {
        CurrentChart = new Chart(ctx, chartConfig);
    }

};

