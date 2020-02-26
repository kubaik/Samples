stack_name="hydra-sample"
compose_file="docker-compose.yml"

up() {
    echo "upping..."
    docker-compose -p $stack_name -f $compose_file up -d
}

up_attach() {
    echo "upping and attach..."
    docker-compose -p $stack_name -f $compose_file up
}

down() {
    echo "downing..."
    docker-compose -p $stack_name -f $compose_file down
}

down_volumes() {
    echo "downing removing volumes..."
    docker-compose -p $stack_name -f $compose_file down -v
}

start() {
    echo "starting..."
    docker-compose -p $stack_name -f $compose_file start
}

stop() {
    echo "stoping..."
    docker-compose -p $stack_name -f $compose_file stop
}

recreate() {
    echo "recreating..."
    down
    up
}

recreate_volumes() {
    echo "recreating removing volumes..."
    down_volumes
    up
}

restart() {
    echo "restarting..."
    stop
    start
}

execute() {
    case $1 in
        "up")
            up;;
        "up attached" | "up-a")
            up_attach;;
        "down")
            down;;
        "down removing volumes" | "down-v")                    
            down_volumes;;
        "start")
            start;;
        "stop")
            stop;;
        "recreate")
            recreate;;
        "recreate-v")
            recreate_volumes;;
        "restart")
            restart;;
        "quit")         
            ;;
        *) echo "invalid option $REPLY";;
    esac
}

if [[ "$@" != "" ]]; then
    execute "$@"
    exit
fi

echo "Please enter your docker-compose action: "
options=("up" "up attached" "down" "down removing volumes" "start" "stop" "recreate" "quit")
select opt in "${options[@]}"
do
    execute $opt
    break
done