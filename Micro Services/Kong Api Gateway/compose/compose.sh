stack_name="kong"

up() {
    echo "upping..."
    docker-compose -p $stack_name up -d
}

down() {
    echo "downing..."
    docker-compose -p $stack_name down
}

down_volumes() {
    echo "downing removing volumes..."
    docker-compose -p $stack_name down -v
}

start() {
    echo "starting..."
    docker-compose -p $stack_name start
}

stop() {
    echo "stoping..."
    docker-compose -p $stack_name stop
}

recreate() {
    echo "recreating..."
    down_volumes
    up
}

execute() {
    case $1 in
        "up")
            up;;
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
options=("up" "down" "down removing volumes" "start" "stop" "recreate" "quit")
select opt in "${options[@]}"
do
    execute $opt
    break
done